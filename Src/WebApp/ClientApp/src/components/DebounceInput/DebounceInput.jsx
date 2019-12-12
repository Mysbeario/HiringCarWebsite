import React, { useState, useEffect, useRef } from "react";
import { Input, FormGroup, Label } from "reactstrap";

const DebounceInput = ({ onInput, type = "text", placeholder = "", label = "", defaultValue = "" }) => {
	const [searchString, setSearchString] = useState("");
	const searchTimeout = useRef();

	useEffect(() => {
		clearTimeout(searchTimeout.current);
		searchTimeout.current = setTimeout(() => {
			onInput(searchString);
		}, 350);
	}, [searchString]);

	return (
		<FormGroup>
			{!!(label) && <Label>{label}</Label>}
			<Input
				type={type}
				placeholder={placeholder}
				onChange={e => setSearchString(e.target.value)}
				defaultValue={defaultValue}
			/>
		</FormGroup>
	);
};

export default DebounceInput;