import React, { useState, useEffect } from "react";
import { Container, Table } from "reactstrap";
import { useParams } from "react-router-dom";
import axios from "axios";
import Car from "../../types/Car";
import BookingForm from "./BookingForm";

const CarInfo = () => {
	const { id } = useParams();
	const [car, setData] = useState(new Car());

	useEffect(() => {
		(async () => {
			const { data } = await axios.get("/api/car/" + id);
			setData(data);
			
		})();
	}, []);

	return (
		<Container>
			<img src={`/api/image/${car.imgPath}`} />
			<Table striped>
				<thead>
					<tr>
						<th>Seat</th>
						<th>Color</th>
						<th>Type</th>
						<th>Cost per day</th>
						<th>Number Plate</th>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td>{car.seat}</td>
						<td>{car.color}</td>
						<td>{car.carTypeName}</td>
						<td>{car.cost} VND</td>
						<td>{car.numberPlate}</td>
						<td></td>
					</tr>
				</tbody>
			</Table>
			<hr />
			<BookingForm car={car} />
		</Container>
	);
};

export default CarInfo;