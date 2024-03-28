import * as React from 'react';
import { useEffect } from "react";
import axios from 'axios';
import { useNavigate } from 'react-router-dom'
import { setAllPatient, deletePatient, setCurrentPatient } from "./store/actions/MembersAction";
import { useDispatch, useSelector } from 'react-redux';
import { useState } from 'react';
import PropTypes from 'prop-types';
import Box from '@mui/material/Box';
import Collapse from '@mui/material/Collapse';
import IconButton from '@mui/material/IconButton';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import CoronavirusOutlinedIcon from '@mui/icons-material/CoronavirusOutlined';
import EditNoteIcon from '@mui/icons-material/EditNote';
import DeleteIcon from '@mui/icons-material/Delete';
import { setAllvaccinations } from './store/actions/VaccinationsAction';
import PersonAddIcon from '@mui/icons-material/PersonAdd';
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
import EditCalendarIcon from '@mui/icons-material/EditCalendar';

export default function Members() {
    const navigate = useNavigate()
    const dis = useDispatch()
    const allPatient = useSelector(s => s.patient.allPatient)
    const allvaccinations = useSelector(s => s.vaccine.allvaccinations)
    const [loading, setLoading] = useState(false);
    const today = new Date()
    const lastMonth = new Date(today.getFullYear(), today.getMonth() - 1, today.getDate())
    const [days, setDays] = useState(new Array(30).fill(0))
    const [unvaccinated, setUnvaccinated] =useState(false);

    // first of all get the patients
    useEffect(() => {
        getAllPatient()
    }, [])

    //get patients from database
    const getAllPatient = async () => {
        const { data } = await axios.get("https://localhost:7245/api/Patient")
        console.log(data)
        dis(setAllPatient(data))
        getAllvaccinations()
    }

    //get all the vaccinations from database
    const getAllvaccinations = async () => {
        const { data } = await axios.get("https://localhost:7245/api/Vaccination")
        console.log(data)
        dis(setAllvaccinations(data))
        setLoading(true)
        console.log(loading)
    }


    // calculate the number of active patients
    const active = async () => {
        allPatient.map(item => {
            let copy= new Array(30).fill(0);
            for (let i = 0; i < 30; i++) {
                const currentDate = new Date(today);
                currentDate.setDate(today.getDate() - i); 
                console.log(Date(item.positive) <= currentDate)     
                if (Date(item.positive) <= currentDate && Date(item.recovery) >= currentDate) {
                    copy[i]++
                }
                console.log(copy)

                setDays(copy);

        }})
        vaccinated()
        return (days)
    }

    // delete patient
    const del = async (id) => {
        try {
            const { data } = await axios.delete("https://localhost:7245/api/Patient/" + id)
            console.log(data)
            dis(deletePatient(id))
            console.log(allPatient)
        }
        catch {
            console.log("could'nt make it")
        }
    }

    //save data for each row
    function createData(name, patientID, city, street, number, dateOfBirth, phone, cellPhone, positive, recovery, id) {
        return {
            id,
            name,
            patientID,
            city,
            street,
            number,
            dateOfBirth,
            phone,
            cellPhone,
            vaccinations: allvaccinations.filter(x => x.patientID == id),
            corona: { positive, recovery }
        };
    }

    //save the selected patient to update
    const setPat = (id) => {
        dis(setCurrentPatient(id))
        navigate("/Patient")
    }

    const addnew = () => {
        navigate("/AddPatient")
    }

    const addVac = (id) => {
        dis(setCurrentPatient(id))
        navigate("/AddVaccine")
    }

    const vaccinated = async () =>{
        let vaccinatedIds = allvaccinations.map(v => v.patientId);
        setUnvaccinated((allPatient.length)-(vaccinatedIds.length))
        console.log(unvaccinated)
    }

    //each row display
    function Row(props) {
        const { row } = props;
        const [open, setOpen] = React.useState(false);

        return (<>{loading ?
            <React.Fragment>
                <TableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
                    <TableCell>
                        <IconButton
                            aria-label="expand row"
                            size="small"
                            onClick={() => setOpen(!open)}
                        >
                            {open ? <KeyboardArrowUpIcon /> : <CoronavirusOutlinedIcon />}
                        </IconButton>
                    </TableCell>
                    <TableCell>
                        <IconButton
                            aria-label="expand row"
                            size="small"
                            onClick={() => del(row.id)}
                        >
                            <DeleteIcon></DeleteIcon>
                        </IconButton>
                    </TableCell>
                    <TableCell>
                        <IconButton
                            aria-label="expand row"
                            size="small"
                            onClick={() => setPat(row.id)}
                        >
                            <EditNoteIcon />
                        </IconButton>
                    </TableCell>
                    <TableCell component="th" scope="row">
                        {row.name}
                    </TableCell>
                    <TableCell align="right">{row.patientID}</TableCell>
                    <TableCell align="right">{row.city + " " + row.street + " " + row.number}</TableCell>
                    <TableCell align="right">{row.dateOfBirth}</TableCell>
                    <TableCell align="right">{row.phone}</TableCell>
                    <TableCell align="right">{row.cellPhone}</TableCell>
                </TableRow>
                <TableRow>
                    <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
                        <Collapse in={open} timeout="auto" unmountOnExit>
                            <Box sx={{ margin: 1 }}>
                                <Typography variant="h6" gutterBottom component="div">
                                    vaccinations
                                </Typography>
                                <Table size="small" aria-label="purchases">
                                    <TableHead>
                                        <TableRow>
                                            <TableCell>ID</TableCell>
                                            <TableCell>Date</TableCell>
                                            <TableCell align="right">Producer</TableCell>
                                        </TableRow>
                                    </TableHead>
                                    <TableBody>
                                        {allvaccinations.filter(x => x.patientId.id == row.id).map(y => (
                                            <TableRow key={y.id}>
                                                <TableCell component="th" scope="row">
                                                    {y.id}
                                                </TableCell>
                                                <TableCell>{y.date}</TableCell>
                                                <TableCell align="right">{y.producer.name}</TableCell>
                                            </TableRow>
                                        ))}
                                        <IconButton
                                            aria-label="expand row"
                                            size="small"
                                            onClick={() => addVac(row.id)}
                                        >
                                            <AddCircleOutlineIcon></AddCircleOutlineIcon>
                                        </IconButton>
                                    </TableBody>
                                </Table>
                            </Box>
                        </Collapse>
                    </TableCell>
                </TableRow>
                <TableRow>
                    <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
                        <Collapse in={open} timeout="auto" unmountOnExit>
                            <Box sx={{ margin: 1 }}>
                                <Typography variant="h6" gutterBottom component="div">
                                    corona
                                </Typography>
                                <Table size="small" aria-label="purchases">
                                    <TableHead>
                                        <TableRow>
                                            <TableCell>Positive result date</TableCell>
                                            <TableCell align="right">Recovery date</TableCell>
                                        </TableRow>
                                    </TableHead>
                                    <TableBody>
                                        <TableRow key={row.id}>
                                            <TableCell component="th" scope="row">
                                                {row.corona.positive}
                                            </TableCell>
                                            <TableCell align="right">{row.corona.recovery}</TableCell>
                                        </TableRow>
                                    </TableBody>
                                </Table>
                            </Box>
                        </Collapse>
                    </TableCell>
                </TableRow>
            </React.Fragment> : console.log("loading")}</>
        );
    }

    //create row for patient
    function rows() {
        return (allPatient.map(x => (createData(x.firstName + " " + x.lastName,
            x.patientID,
            x.city,
            x.street,
            x.number,
            x.dateOfBirth,
            x.phone,
            x.cellPhone,
            x.positive,
            x.recovery,
            x.id))))
    }

    //table display
    return (<>{loading ?
        <div>
            <IconButton
                aria-label="expand row"
                size="small"
                onClick={() => active()}  >
                <EditCalendarIcon />
            </IconButton><br/>
            Summary of the last month: <>{days}</>
            <div>The number of unvaccinated members: {unvaccinated}</div>
            <TableContainer component={Paper}>
                <Table aria-label="collapsible table">
                    <TableHead>
                        <TableRow>
                            <TableCell><IconButton
                                aria-label="expand row"
                                size="small"
                                onClick={() => addnew()}
                            >
                                <PersonAddIcon />
                            </IconButton></TableCell>
                            <TableCell />
                            <TableCell />
                            <TableCell>Name</TableCell>
                            <TableCell align="right">ID</TableCell>
                            <TableCell align="right">Address</TableCell>
                            <TableCell align="right">Date of birth</TableCell>
                            <TableCell align="right">Phone</TableCell>
                            <TableCell align="right">cellPhone</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows().map((row) => (
                            <Row key={row.id} row={row} />
                        ))}
                    </TableBody>
                </Table>
            </TableContainer></div> : <h1>loading...</h1>}</>
    );
}