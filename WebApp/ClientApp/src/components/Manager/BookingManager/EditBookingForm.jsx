import React from "react";
import { Alert, Modal, ModalHeader, ModalFooter, ModalBody, Label, Input, FormGroup, Form, Button } from "reactstrap";
import axios from "axios";
import useAlertState from "../../../hooks/useAlertState";
import Booking from "../../../types/Booking";
import { nowToString } from "../../../utilities";

const validate = data => {
	const err = [];

	for (let e of data.keys()) {
		if (!data.get(e)) {
			err.push("All fields must be filled!");
			break;
		}
	}

	return err;
};

const EditBookingForm = ({ isOpen, toggle, onSubmit, item = new Booking() }) => {
	const [alertState, changeAlertState, resetAlertState] = useAlertState(2000);

	const edit = async e => {
		e.preventDefault();
		const formData = new FormData(e.target);
		console.log(item);
		const errors = validate(formData);

		if (!errors.length) {
			try {
				await axios.put("api/booking/" + item.id, formData);
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
			<ModalHeader toggle={toggle}>Edit Booking Information</ModalHeader>
			{alertState.status !== "none" && <Alert color={alertState.status}>
				<ul>
					{alertState.messages.map(msg => <li>{msg}</li>)}
				</ul>
			</Alert>}
			<Form onSubmit={edit}>
				<ModalBody>
					<Input type="hidden" name="Id" id="Id" value={item.id} />
					<Input type="hidden" name="CarId" id="CarId" value={item.carId} />
					<Input type="hidden" name="UserId" id="UserId" value={item.userId} />
					<Input type="hidden" name="Status" id="Status" value={item.status} />
					<FormGroup>
						<Label htmlFor="PickUpDate">Pick-up Date</Label>
						<Input type="date" name="PickUpDate" id="PickUpDate" defaultValue={item.pickUpDate} min={nowToString()} />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="DropOffDate">Drop-off Date</Label>
						<Input type="date" name="DropOffDate" id="DropOffDate" defaultValue={item.dropOffDate} />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="PickUpLocation">Pick-up Location</Label>
						<Input type="text" name="PickUpLocation" id="PickUpLocation" defaultValue={item.pickUpLocation} />
					</FormGroup>
					<FormGroup>
						<Label htmlFor="DropOffLocation">Drop-off Location</Label>
						<Input type="text" name="DropOffLocation" id="DropOffLocation" defaultValue={item.dropOffLocation} />
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

export default EditBookingForm;