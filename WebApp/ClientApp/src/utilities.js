export const toString = obj => {
	if (typeof obj !== "undefined" && obj !== null) return obj.toString();
	return obj;
};
