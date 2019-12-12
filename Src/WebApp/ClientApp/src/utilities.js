export const toString = obj => {
	if (typeof obj !== "undefined" && obj !== null) return obj.toString();
	return obj;
};

export const nowToString = () => {
	const now = new Date();
	return `${now.getFullYear()}-${now.getMonth() + 1}-${now.getDate()}`;
};