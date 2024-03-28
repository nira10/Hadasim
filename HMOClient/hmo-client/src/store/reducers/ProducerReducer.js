import * as actionType from '../actionType'

const initialState = {  //state for producer
    allproducer: [],
}

export default function ProducerReducer(state = initialState, action) {

    switch (action.type) {
        case actionType.SET_ALL_PRODUCERS:  //load producers
            console.log(action.payload)
            return { allproducer: action.payload }
        }
    return state;
}
    