import React from "react";
import { Alert, Modal, ModalHeader, ModalFooter, ModalBody, Label, Input, FormGroup, Form, Button } from "reactstrap";
import axios from "axios";
import useAlertState from "../../../hooks/useAlertState";
import validate from "./validation";

const AddCarTypeForm = ({ isOpen, toggle, onSubmit }) => {
	const [alertState, changeAlertState, resetAlertState] = useAlertState(5000);

	const create = async e => {
		e.preventDefault();
		const form = e.target;
		const formData = new FormData(form);
		const errors = validate(formData);

		if (!errors.length) {
			try {
				changeAlertState("primary", ["Adding ..."]);
				await axios.post("api/cartype", formData);
				changeAlertState("success",["New car type added!"]);
				resetAlertState();
				form.reset();
				onSubmit();
			}
			catch (e) {
				changeAlertState("danger", ["Failed to add!"]);
				resetAlertState();
			}
		} else {
			changeAlertState("danger", errors);
			resetAlertState();
		}
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader toggle={toggle}>Add Car Type</ModalHeader>
			{alertState.status !== "none" &&
				<Alert color={alertState.status}>
					<ul>
						{alertState.messages.map(msg => <li>{msg}</li>)}
					</ul>
				</Alert>}
			<Form onSubmit={create}>
				<ModalBody>
					<FormGroup>
						<Label htmlFor="Name">Name</Label>
						<Input type="text" name="Name" id="Name" />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="Seat">Number of Seat</Label>
						<Input type="number" name="Seat" id="Seat" />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="Cost">Cost per Day (VND)</Label>
						<Input type="number" name="Cost" id="Cost" />
					</FormGroup>
				</ModalBody>
				<ModalFooter>
					<Button color="primary" type="submit">Add</Button>
					<Button color="danger" type="reset">Reset</Button>
				</ModalFooter>
			</Form>
		</Modal>
	);
};

export default AddCarTypeForm;