import React from "react";
import { Modal, ModalHeader, ModalFooter, ModalBody, Input, Form, Button } from "reactstrap";
import axios from "axios";
import Booking from "../../../types/Booking";

const CancelBookingForm = ({ isOpen, toggle, onSubmit, item = new Booking() }) => {
	const remove = async e => {
		e.preventDefault();
		await axios.put("api/status/booking/" + item.id + "?Action=cancel");
		toggle();
		onSubmit();
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader className="text-danger" toggle={toggle}>Cancel Booking</ModalHeader>
			<Form onSubmit={remove}>
				<ModalBody>
					<Input type="hidden" name="Id" id="Id" value={item.id} />
					<p className="text-danger">Do you really want to <strong>cancel</strong> this booking?</p>
					<ul className="text-danger">
						<li><strong>ID:</strong> {item.id}</li>
						<li><strong>Car Number Plate:</strong> {item.numberPlate}</li>
						<li><strong>User Email:</strong> {item.userEmail}</li>
					</ul>
				</ModalBody>
				<ModalFooter>
					<Button color="danger" type="submit">Cancel Booking</Button>
					<Button className="text-danger" color="link" onClick={toggle}>Back</Button>
				</ModalFooter>
			</Form>
		</Modal>
	);
};

export default CancelBookingForm;