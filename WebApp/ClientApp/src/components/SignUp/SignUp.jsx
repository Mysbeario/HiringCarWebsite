import React from "react";
import { Form, FormGroup, Label, Input, Button } from "reactstrap";
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
	const create = e => {
		const form = e.target;
		const data = new FormData(form);

		(async () => {
			await axios.post("/api/customer", data);
			form.reset();
		})()
	};

	return (
		<SignUpFormWrapper>
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
