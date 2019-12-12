import React from "react";
import { useHistory } from "react-router-dom";
import { Modal, ModalHeader, ModalFooter, ModalBody, Input, Form, Button } from "reactstrap";
import axios from "axios";
import Booking from "../../../types/Booking";

const CheckoutBookingForm = ({ isOpen, toggle, onSubmit, item = new Booking() }) => {
	const history = useHistory();
	const remove = async e => {
		try {
			e.preventDefault();
			await axios.put("api/status/booking/" + item.id + "?Action=finish");
			toggle();
			onSubmit();
		}
		catch (e) {
			history.push("/login");
		}
	};

	return (
		<Modal isOpen={isOpen} toggle={toggle}>
			<ModalHeader className="text-success" toggle={toggle}>Checkout Booking</ModalHeader>
			<Form onSubmit={remove}>
				<ModalBody>
					<Input type="hidden" name="Id" id="Id" value={item.id} />
					<p className="text-success">Do you really want to <strong>checkout</strong> this booking?</p>
					<ul className="text-success">
						<li><strong>ID:</strong> {item.id}</li>
						<li><strong>Car Number Plate:</strong> {item.numberPlate}</li>
						<li><strong>User Email:</strong> {item.userEmail}</li>
					</ul>
				</ModalBody>
				<ModalFooter>
					<Button color="success" type="submit">Checkout Booking</Button>
					<Button className="text-danger" color="link" onClick={toggle}>Back</Button>
				</ModalFooter>
			</Form>
		</Modal>
	);
};

export default CheckoutBookingForm;