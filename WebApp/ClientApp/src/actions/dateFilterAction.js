export const DateFilterAction = {
	SetStartDay: "set start day",
	SetEndDay: "set end day"
};

export const setStartDay = day => {
	return {
		type: DateFilterAction.SetStartDay,
		day
	};
};

export const setEndDay = day => {
	return {
		type: DateFilterAction.SetEndDay,
		day
	};
};
