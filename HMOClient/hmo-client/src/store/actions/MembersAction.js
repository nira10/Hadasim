import * as actionType from '../actionType'

export function setAllPatient(allPatient) {
    return {
        type: actionType.SET_ALL_PATIENT,
        payload: allPatient
    }
}
export function deletePatient(id) {
    return {
        type: actionType.DELETE_PATIENT,
        payload: id
    }
}
export function setCurrentPatient(id) {
    return {
        type: actionType.SET_CURRENT_PATIENT,
        payload: id
    }
}
export function setOnePatient(patient) {
    return {
        type: actionType.SET_ONE_PATIENT,
        payload: patient
    }
}