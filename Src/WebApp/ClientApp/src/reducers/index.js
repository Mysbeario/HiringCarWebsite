import accountReducer from "./accountReducer";
import dateFilterReducer from "./dateFilterReducer";
import { combineReducers } from "redux";

const reducer = combineReducers({ account: accountReducer, dateFilter: dateFilterReducer });

export default reducer;