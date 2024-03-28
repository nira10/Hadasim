import * as actionType from '../actionType'

const initialState = {
    allPatient: [],
    Patient: null
}
export default function MembersReducer(state = initialState, action) {

    switch (action.type) {
        case actionType.SET_ALL_PATIENT:  //load all the patients
            return { allPatient: action.payload }

        case actionType.DELETE_PATIENT:  //remove patient
            let copy = state.allPatient.filter(x => x.id != action.payload)
            return {
                allPatient: copy
            }
        case actionType.SET_CURRENT_PATIENT:  //save selected patient
            let cop = state.allPatient.filter(x => x.id == action.payload)
            console.log(cop[0])
            return { Patient: cop[0] }

        case actionType.SET_ONE_PATIENT:  //update patient
            let copy1 = state.allPatient.filter(x => x.id == action.payload.id)
            copy1[0]= action.payload
            console.log(copy1[0]) 
            return {allPatient: copy1}   
    }
    return state;
}
