import * as actionType from '../actionType'

export function setAllProducers(allproducer) {
    return {
        type: actionType.SET_ALL_PRODUCERS,
        payload: allproducer
    }
}