import React, { useState, useEffect } from "react";
import { useSelector } from "react-redux";
import { Form, Input, FormGroup, Row, Col, Label, Button } from "reactstrap";
import ConfirmModal from "./ConfirmModal";
import { nowToString } from "../../utilities";

const datesDifferenceCalculate = (from, to) => {
	const diffTime = Math.abs(from - to);
	const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
	return diffDays + 1;
};

const BookingForm = ({ car }) => {
	const dateFilter = useSelector(state => state.dateFilter);
	const [startDay, setFromDate] = useState(dateFilter.startDay);
	const [toDate, setEndDate] = useState(dateFilter.endDay);
	const [days, setDays] = useState(0);
	const [bookingData, setBookingData] = useState(new FormData());

	useEffect(() => {
		const diff = datesDifferenceCalculate(new Date(startDay), new Date(toDate)) || 0;
		setDays(diff);
	}, [startDay, toDate]);

	const confirm = async e => {
		e.preventDefault();
		const formData = new FormData(e.target);
		formData.append("Cost", car.cost * days);
		setBookingData(formData);
	};

	return (
		<>
			<Form onSubmit={confirm}>
				<h3>Booking Information</h3>
				<Input type="hidden" defaultValue={car.id} name="CarId" id="CarId" />
				<Row form>
					<Col>
						<FormGroup>
							<Label htmlFor="PickUpDate">Pick-up Date</Label>
							<Input type="date" defaultValue={dateFilter.startDay} id="PickUpDate" name="PickUpDate" min={nowToString()} onChange={e => setFromDate(e.target.value)} />
						</FormGroup>
					</Col>
					<Col>
						<FormGroup>
							<Label htmlFor="DropOffDate">Drop-off Date</Label>
							<Input type="date" defaultValue={dateFilter.endDay} id="DropOffDate" name="DropOffDate" onChange={e => setEndDate(e.target.value)} />
						</FormGroup>
					</Col>
				</Row>
				<Row form>
					<Col>
						<FormGroup>
							<Label htmlFor="PickUpLocation">Pick-up Location</Label>
							<Input type="text" id="PickUpLocation" name="PickUpLocation" />
						</FormGroup>
					</Col>
					<Col>
						<FormGroup>
							<Label htmlFor="DropOffLocation">Drop-off Location</Label>
							<Input type="text" id="DropOffLocation" name="DropOffLocation" />
						</FormGroup>
					</Col>
				</Row>
				<hr />
				<div>Unit Price x Day(s) - {car.cost} VND x {days} </div>
				<div><h5>Total: {car.cost * days} VND</h5></div>
				<hr />
				<Row form>
					<Col xs={1}>
						<ConfirmModal booking={bookingData} car={car} />
					</Col>
					<Col xs={1}>
						<Button color="danger" type="reset">Reset</Button>
					</Col>
				</Row>
			</Form>
		</>
	);
};

export default BookingForm;