import * as actionType from '../actionType'

const initialState = {  //state for vaccination
    allvaccinations: [],
}

export default function VaccinationsReducer(state = initialState, action) {

    switch (action.type) {
        case actionType.SET_ALL_VACCINATIONS:  //load vaccinations
            return { allvaccinations: action.payload }
        }
    return state;
}
    
