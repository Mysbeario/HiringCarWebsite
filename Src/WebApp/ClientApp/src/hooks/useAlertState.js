import { useState } from "react";

const useAlertState = (timeOut = 2000) => {
	const init = { status: "none", messages: [] };
	const [alertState, setAlertState] = useState(init);
	const resetAlertState = () => setTimeout(() => setAlertState(init), timeOut);
	const changeAlertState = (status, messages) => setAlertState({ status, messages });

	return [alertState, changeAlertState, resetAlertState];
};

export default useAlertState;