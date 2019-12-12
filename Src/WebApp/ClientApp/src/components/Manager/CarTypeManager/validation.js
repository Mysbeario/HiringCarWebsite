const validate = data => {
	const errors = [];

	for (let e of data.keys()) {
		if (!data.get(e)) {
			errors.push("All fields must be filled!");
			break;
		}
	}

	if (data.get("Seat") < 2 || data.get("Seat") > 10) {
		errors.push("Number of seats must be between 2 - 10 seats.")
	}

	if (data.get("Cost") < 0) {
		errors.push("Invalid Cost per day!");
	}

	return errors;
};

export default validate;