import './App.css';
import {BrowserRouter as Router,Route, Routes} from 'react-router-dom'
import Members from './Members';
import Patient from './Patient';
import AddPatient from './AddPatient'
import AddVaccine from './AddVaccine';


function App() {
  return (
    <>
    <Router>
      <Routes>
      <Route path='/' element={<Members/>}/>
      <Route path='/Patient' element={<Patient/>}/>
      <Route path='/AddPatient' element={<AddPatient/>}/>
      <Route path='/AddVaccine' element={<AddVaccine/>}/>
      </Routes>
    </Router> 
  </>
  );
}

export default App;
