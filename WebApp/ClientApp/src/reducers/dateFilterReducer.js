import { DateFilterAction } from "../actions";

const init = {
	startDay: "",
	endDay: ""
};

const dateFilterReducer = (state = init, action) => {
	switch (action.type) {
		case DateFilterAction.SetStartDay:
			return {
				...state,
				startDay: action.day
			};
		case DateFilterAction.SetEndDay:
			return {
				...state,
				endDay: action.day
			};
		default:
			return state;
	}
};

export default dateFilterReducer;