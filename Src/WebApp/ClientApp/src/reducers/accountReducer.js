import { AccountAction } from "../actions";

const init = {
	status: "unauthenticated"
};

const accountReducer = (state = init, action) => {
	switch (action.type) {
		case AccountAction.Auth: 
			return {
				status: "authenticated"
			}
		case AccountAction.Reject:
			return {
				status: "unauthenticated"
			}
		default:
			return state;
	}
};

export default accountReducer;