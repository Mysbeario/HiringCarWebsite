import React from "react";
import { Alert, Modal, ModalHeader, ModalFooter, ModalBody, Label, Input, FormGroup, Form, Button } from "reactstrap";
import axios from "axios";
import CarType from "../../../types/CarType";
import useAlertState from "../../../hooks/useAlertState";
import validate from "./validation";

const EditCarTypeForm = ({ isOpen, toggle, onSubmit, item = new CarType() }) => {
	const [alertState, changeAlertState, resetAlertState] = useAlertState(2000);

	const edit = async e => {
		e.preventDefault();
		const formData = new FormData(e.target);
		const errors = validate(formData);

		if (!errors.length) {
			try {
				await axios.put("api/cartype/" + item.id, formData);
				toggle();
				onSubmit();
			}
			catch (e) {
				changeAlertState("danger", ["Failed to edit!"]);
				resetAlertState();
			}
		} else {
			changeAlertState("danger", errors);
		}
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader toggle={toggle}>Edit Car Type</ModalHeader>
			{alertState.status !== "none" && <Alert color={alertState.status}>
				<ul>
					{alertState.messages.map(msg => <li>{msg}</li>)}
				</ul>
			</Alert>}
			<Form onSubmit={edit}>
				<ModalBody>
					<Input type="hidden" name="Id" id="Id" value={item.id} />
					<FormGroup>
						<Label htmlFor="Name">Name</Label>
						<Input type="text" name="Name" id="Name" defaultValue={item.name} />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="Seat">Number of Seat</Label>
						<Input type="number" name="Seat" id="Seat" defaultValue={item.seat} />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="Cost">Cost per Day (VND)</Label>
						<Input type="number" name="Cost" id="Cost" defaultValue={item.cost} />
					</FormGroup>
				</ModalBody>
				<ModalFooter>
					<Button color="primary" type="submit">Edit</Button>
					<Button color="danger" type="reset">Reset</Button>
				</ModalFooter>
			</Form>
		</Modal>
	);
};

export default EditCarTypeForm;