import React, { useEffect } from "react";
import { Form, FormGroup, Label, Input, Button, Alert } from "reactstrap";
import styled from "styled-components";
import axios from "axios";
import { useDispatch, useSelector } from "react-redux";
import useAlertState from "../../hooks/useAlertState";
import { AccountAction } from "../../actions";

const SignUpFormWrapper = styled.div`
	box-sizing: border-box;
	margin: auto;
	width: 80%;
	padding: 2em;
	border: 0.25em solid gray;
	border-radius: 0.5em;
`;

const LogIn = ({ history }) => {
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

	const login = e => {
		e.preventDefault();
		const form = e.target;
		const data = new FormData(form);
		const errors = [];

		for (let k of data.keys()) {
			if (data.get(k) == null) {
				errors.push("All fields must be filled!");
				break;
			}
		}

		if (!errors.length) {
			(async () => {
				changeAlertState("primary", ["Logging in ..."])
				try {
					await axios.post("/api/user/login", data);
					form.reset();
					changeAlertState("success", ["Successfully login!"]);
					dispatch({ type: AccountAction.Auth });
					setTimeout(() => history.push("/"), 3000);
				}
				catch (err) {
					changeAlertState("danger", ["Wrong email or password!"]);
					dispatch({ type: AccountAction.Reject });
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
				<Form onSubmit={login}>
					<h1>Log In</h1>
					<hr />
					<FormGroup>
						<Label htmlFor="Email">Email</Label>
						<Input type="email" id="Email" name="Email" />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="Password">Password</Label>
						<Input type="password" id="Password" name="Password" />
					</FormGroup>
					<hr />
					<FormGroup>
						<Button color="primary" type="submit">Log In</Button>
					</FormGroup>
				</Form>
			</SignUpFormWrapper>}
		</>
	);
};

export default LogIn;
