import accountReducer from "./accountReducer";
import { combineReducers } from "redux";

const reducer = combineReducers({ account: accountReducer });

export default reducer;