import React, { useState } from "react";
import { Form, FormGroup, Label, Input, Button, Alert } from "reactstrap";
import styled from "styled-components";
import axios from "axios";

const SignUpFormWrapper = styled.div`
	box-sizing: border-box;
	margin: auto;
	width: 80%;
	padding: 2em;
	border: 0.25em solid gray;
	border-radius: 0.5em;
`;

const SignUp = () => {
	const [validationErrors, setValidationErrorList] = useState([]);

	const create = e => {
		e.preventDefault();
		const form = e.target;
		const data = new FormData(form);
		const errors = [];

		if (!errors.length) {
			(async () => {
				try {
					await axios.post("/api/user/register", data);
					form.reset();
				}
				catch (err) {
					const errResponse = err.response.data.errors;
					for (let e in err.response.data.errors) {
						errors.push(errResponse[e][0]);
					}
					setValidationErrorList(errors);
				}
			})();
		}
	};

	return (
		<SignUpFormWrapper>
			{!!validationErrors.length && <Alert color="danger">
				<ul>
					{validationErrors.map(err => <li>{err}</li>)}
				</ul>
			</Alert>}
			<Form onSubmit={create}>
				<h1>Create New Account</h1>
				<hr />
				<FormGroup>
					<Label htmlFor="Email">Email</Label>
					<Input type="email" id="Email" name="Email" />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="Password">Password</Label>
					<Input type="password" id="Password" name="Password" />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="ConfirmPassword">Confirm Password</Label>
					<Input type="password" id="ConfirmPassword" name="ConfirmPassword" />
				</FormGroup>
				<hr />
				<FormGroup>
					<Button color="primary" type="submit">Sign Up</Button>
				</FormGroup>
			</Form>
		</SignUpFormWrapper>
	);
};

export default SignUp;
