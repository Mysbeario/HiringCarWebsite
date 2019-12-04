import React, { useState, useEffect, useRef } from "react";
import { Col, Input } from "reactstrap";

const SearchBox = ({ onInput }) => {
	const [searchString, setSearchString] = useState("");
	const searchTimeout = useRef();

	useEffect(() => {
		clearTimeout(searchTimeout.current);
		searchTimeout.current = setTimeout(() => {
			onInput(searchString);
		}, 350);
	}, [searchString]);

	return (
		<Col>
			<Input 
				type="text"
				placeholder="Search..."
				onChange={e => setSearchString(e.target.value)}
			/>
		</Col>
	);
};

export default SearchBox;