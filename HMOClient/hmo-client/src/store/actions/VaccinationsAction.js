import * as actionType from '../actionType'

export function setAllvaccinations(allvaccinations) {
    return {
        type: actionType.SET_ALL_VACCINATIONS,
        payload: allvaccinations
    }
}