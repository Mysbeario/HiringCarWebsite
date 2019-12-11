import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import axios from "axios";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

const ConfirmModal = ({ booking, car }) => {
	const [modal, setModal] = useState(false);
	const history = useHistory();

	const toggle = () => setModal(!modal);

	const book = async () => {
		try {
			await axios.post("api/booking", booking);
			toggle();
		}
		catch (e) {
			if (e.response.status === 401) {
				history.push("/login");
			}
		}
	};

	return (
		<div>
			<Button type="submit" color="primary" onClick={toggle}>Book</Button>
			<Modal isOpen={modal} toggle={toggle}>
				<ModalHeader toggle={toggle}>Confirm Booking Information</ModalHeader>
				<ModalBody>
					<p><strong>Car Type: </strong>{car.carTypeName}</p>
					<p><strong>Seat: </strong>{car.seat}</p>
					<p><strong>Number Plate: </strong>{car.numberPlate}</p>
					<p><strong>Color: </strong>{car.color}</p>
					<hr />
					<p>Pick up at {booking.get("PickUpLocation")} on <strong>{new Date(booking.get("PickUpDate")).toDateString()}</strong></p>
					<p>Drop off at {booking.get("DropOffLocation")} on <strong>{new Date(booking.get("DropOffDate")).toDateString()}</strong></p>
					<hr />
					<h4>Total: {booking.get("Cost")} VND</h4>
				</ModalBody>
				<ModalFooter>
					<Button color="primary" onClick={book}>Confirm</Button>{' '}
					<Button color="secondary" onClick={toggle}>Cancel</Button>
				</ModalFooter>
			</Modal>
		</div>
	);
};

export default ConfirmModal;