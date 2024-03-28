import * as React from 'react';
import { useNavigate } from 'react-router-dom'
import { setAllPatient, deletePatient, setCurrentPatient, setOnePatient } from "./store/actions/MembersAction";
import { useDispatch, useSelector } from 'react-redux';
import { useState } from 'react';
import { useEffect } from "react";
import {setAllProducers} from "./store/actions/ProducerAction"
import axios from 'axios';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import SaveAltIcon from '@mui/icons-material/SaveAlt';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormHelperText from '@mui/material/FormHelperText';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

export default function AddVaccine() {
    const navigate = useNavigate()
    const dis = useDispatch()
    const patient = useSelector(s => s.patient.Patient)
    const [loading, setLoading] = useState(false);
    const all = useSelector(p => p.prod.allproducer);

    // first of all get the producers
    useEffect(() => {
        getAllProducer()
    }, [])

    //get producers from database
    const getAllProducer = async () => {
        const { data } = await axios.get("https://localhost:7245/api/Producer")
        console.log(data)
        dis(setAllProducers(data))
        setLoading(true)
    }

    // saving data
    const [formData, setFormData] = useState({
        id: "",
        producer: {},
        date: new Date(),
        patientId: patient
    });

    //validation
    const isFormDataValid = () => {

        // check date
        try {
            const date = new Date(formData.date);
            if (isNaN(date.getTime())) {
                return false;
            }
        } catch (error) {
            return false;
        }
        // Check if other fields are not empty
        if (
            formData.producer == {} ||
            formData.patientId == {}
        ) {
            return false;
        }

        return true;
    };

    // save changes
    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const handleChange = (event) =>{
        const { name, value } = event.target;
        let copy = all.filter(x => x.name == value)
        setFormData({
            ...formData,
            producer: copy[0]
        })
    }

    // update patient 
    const save = async () => {
        if (isFormDataValid()) {
            await axios.post("https://localhost:7245/api/Vaccination", formData)
            navigate("/")
        }
        else console.log("Invalid")
    }

    // display
    return (<>{loading ? <>

        <Box>
            <TextField
                id="date"
                label="date"
                name="date"
                value={formData.date}
                variant="standard"
                onChange={handleInputChange}
            />
        </Box>
        <Box sx={{ minWidth: 120 }}>
      <FormControl fullWidth>
        <InputLabel id="demo-simple-select-label">Age</InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={"producer"}
          label="producer"
          onChange={handleChange}
        > <MenuItem></MenuItem>
        {all.map(x => {
          return(<MenuItem value={x.id}>{x.name}</MenuItem>)})}
        </Select>
      </FormControl>
    </Box>

        <Button variant="outlined" startIcon={<SaveAltIcon />} onClick={() => save()}>
            save
        </Button></> : console.log("loading...")}
    </>)
}