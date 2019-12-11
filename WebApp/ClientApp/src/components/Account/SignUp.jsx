import React, { useEffect } from "react";
import { Form, FormGroup, Label, Input, Button, Alert } from "reactstrap";
import { useDispatch, useSelector } from "react-redux";
import { AccountAction } from "../../actions";
import styled from "styled-components";
import axios from "axios";
import useAlertState from "../../hooks/useAlertState";

const SignUpFormWrapper = styled.div`
	box-sizing: border-box;
	margin: auto;
	width: 80%;
	padding: 2em;
	border: 0.25em solid gray;
	border-radius: 0.5em;
`;

const SignUp = ({ history }) => {
	const [alertState, changeAlertState] = useAlertState(5000);
	const authStatus = useSelector(state => state.account.status);
	const dispatch = useDispatch();

	useEffect(() => {
		(async () => {
			try {
				await axios.get("/api/user/auth");
				dispatch({ type: AccountAction.Auth });
				history.push("/");
			}
			catch (e) {
				dispatch({ type: AccountAction.Reject });
			}
		})();
	}, []);

	const validate = data => {
		const errors = [];

		for (let e of data.keys()) {
			if (!data.get(e)) {
				errors.push("All fields must be filled!");
				break;
			}
		}

		if (!/^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$/.test(data.get("Email"))) {
			errors.push("Invalid email address!");
		}
		if (!/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{6,24}$/.test(data.get("Password"))) {
			errors.push("Password must have at least 1 uppercase letter, 1 lowercase letter, 1 numberic character, 1 nonalphanumberic character and includes 6 - 24 characters");
		}
		else if (data.get("Password") !== data.get("ConfirmPassword")) {
			errors.push("Passwords don't match");
		}

		return errors;
	};

	const create = e => {
		e.preventDefault();
		const form = e.target;
		const data = new FormData(form);
		const errors = validate(data);

		if (!errors.length) {
			(async () => {
				changeAlertState("primary", ["Registering ..."])
				try {
					await axios.post("/api/user/register", data);
					form.reset();
					changeAlertState("success", ["Successfully register new account!"]);
					setTimeout(() => history.push("/"), 3000);
				}
				catch (err) {
					changeAlertState("danger", ["Failed to register new account!"]);
				}
			})();
		} else {
			changeAlertState("danger", errors);
		}
	};

	return (
		<>
			{authStatus === "unauthenticated" && <SignUpFormWrapper>
				{alertState.status !== "none" && <Alert color={alertState.status}>
					<ul>
						{alertState.messages.map(msg => <li>{msg}</li>)}
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
			</SignUpFormWrapper>}
		</>
	);
};

export default SignUp;
