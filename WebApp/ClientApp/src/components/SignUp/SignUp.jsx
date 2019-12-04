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

		for (const k of data.values()) {
			if (k.length === 0) {
				errors.push("All fields must be filled!");
				break;
			}
		}

		if (!/^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$/.test(data.get("Email"))) {
			errors.push("Invalid email address!");
		}

		if (data.get("Password").length <= 8 || data.get("Password").length >= 32) {
			errors.push("Password length must be 8 - 32 characters!");
		}
		else if (data.get("Password") !== data.get("ConfirmPassword")) {
			errors.push("Password does not match!");
		}

		setValidationErrorList(errors);

		if (!errors.length) {
			(async () => {
				await axios.post("/api/customer", data);
				form.reset();
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
				<FormGroup>
					<Label htmlFor="FirstName">First Name</Label>
					<Input type="text" id="FirstName" name="FirstName" />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="LastName">Last Name</Label>
					<Input type="text" id="LastName" name="LastName" />
				</FormGroup>
				<FormGroup>
					<Label htmlFor="PhoneNumber">Phone Number</Label>
					<Input type="tel" id="PhoneNumber" name="PhoneNumber" />
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
