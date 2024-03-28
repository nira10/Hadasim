import * as React from 'react';
import { useNavigate } from 'react-router-dom'
import { setAllPatient, deletePatient, setCurrentPatient, setOnePatient } from "./store/actions/MembersAction";
import { useDispatch, useSelector } from 'react-redux';
import { useState } from 'react';
import { useEffect } from "react";
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
/*import * as React from 'react';      להעלאת תמונה
import { styled } from '@mui/material/styles';
import Button from '@mui/material/Button';
import CloudUploadIcon from '@mui/icons-material/CloudUpload';

const VisuallyHiddenInput = styled('input')({
clip: 'rect(0 0 0 0)',
clipPath: 'inset(50%)',
height: 1,
overflow: 'hidden',
position: 'absolute',
bottom: 0,
left: 0,
whiteSpace: 'nowrap',
width: 1,
});

export default function InputFileUpload() {
return (
<Button
  component="label"
  role={undefined}
  variant="contained"
  tabIndex={-1}
  startIcon={<CloudUploadIcon />}
>
  Upload file
  <VisuallyHiddenInput type="file" />
</Button>
);
}*/
export default function Patient() {
    const navigate = useNavigate()
    const dis = useDispatch()
    const patient = useSelector(s => s.patient.Patient)
    const [loading, setLoading] = useState(true);

    // saving data
    const [formData, setFormData] = useState({
        id: patient.id,
        firstName: patient.firstName,
        lastName: patient.lastName,
        patientID: patient.patientID,
        city: patient.city,
        street: patient.street,
        number: patient.number,
        dateOfBirth: patient.dateOfBirth,
        phone: patient.phone,
        cellPhone: patient.cellPhone,
        vaccinations: [],
        positive: patient.positive,
        recovery: patient.recovery
    });

    //validation
    const isFormDataValid = () => {  
        // Check if patientID/phone/number is valid (contains only digits)
        const patientIdRegex = /^\d+$/;
        if (!patientIdRegex.test(formData.patientID))return false;
        if (!patientIdRegex.test(formData.cellPhone)) return false;
        if (!patientIdRegex.test(formData.phone)) return false;
        if (!patientIdRegex.test(formData.number)) return false;
        
        // check date
        try {
            const date = new Date(formData.dateOfBirth);
            if (isNaN(date.getTime())) {
              return false;
            }
          } catch (error) {
            return false; 
          }    
        // Check if other fields are not empty
        if (
            formData.firstName== "" ||
            formData.lastName== "" ||
            formData.city== "" ||
            formData.street== "" ||
            formData.number== "" ||
            formData.dateOfBirth== null
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
    
    // update patient 
    const save = async () => {
        if (isFormDataValid()){
        let data
        await axios.put("https://localhost:7245/api/Patient/" + patient.id, formData)
            .then({ data } = await axios.get("https://localhost:7245/api/Patient/" + patient.id))
        navigate("/")}
        else console.log("Invalid")
    }

    // display
    return (<>{loading?<>
    <Box>
        <TextField
            id="patientID"
            label="patient ID"
            name="patientID"
            value={formData.patientID}
            variant="standard"
            onChange={handleInputChange}
        />
    </Box>
    <Box>
        <TextField
            id="firstName"
            label="first name"
            name="firstName"
            value={formData.firstName}
            variant="standard"
            onChange={handleInputChange}
        />
    </Box>  
    <Box>
        <TextField
            id="lastName"
            label="last name"
            name="lastName"
            value={formData.lastName}
            variant="standard"
            onChange={handleInputChange}
        />
    </Box>   
        <Box>
            <TextField
                id="city"
                label="city"
                name="city"
                value={formData.city}
                variant="standard"
                onChange={handleInputChange}
            />
        </Box>
        <Box>
            <TextField
                id="street"
                label="street"
                name="street"
                value={formData.street}
                variant="standard"
                onChange={handleInputChange}
            />
        </Box>
        <Box>
            <TextField
                id="number"
                label="house number"
                name="number"
                value={formData.number}
                variant="standard"
                onChange={handleInputChange}
            />
        </Box>
        <Box>
            <TextField
                id="phone"
                label="phone"
                name="phone"
                value={formData.phone}
                variant="standard"
                onChange={handleInputChange}
            />
        </Box>
        <Box>
            <TextField
                id="cellPhone"
                label="cellPhone"
                name="cellPhone"
                value={formData.cellPhone}
                variant="standard"
                onChange={handleInputChange}
            />
        </Box>
        <Box>
            <TextField
                id="dateOfBirth"
                label="date of birth"
                name="dateOfBirth"
                value={formData.dateOfBirth}
                variant="standard"
                onChange={handleInputChange}
            />
        </Box>
        <Box>
            <TextField
                id="positive"
                label="positive"
                name="positive"
                value={formData.positive}
                variant="standard"
                onChange={handleInputChange}
            />
        </Box>
        <Box>
            <TextField
                id="recovery"
                label="recovery"
                name="recovery"
                value={formData.recovery}
                variant="standard"
                onChange={handleInputChange}
            />
        </Box>
        <Button variant="outlined" startIcon={<SaveAltIcon />} onClick={() => save()}>
            save
        </Button></>:console.log("loading...")}
        </>)
}