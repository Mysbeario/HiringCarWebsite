import React from "react";
import { Table, Button } from "reactstrap";

const BookingTable = ({ data, onAction }) => {
	return (
		<Table striped>
			<thead>
				<tr>
					<th>ID</th>
					<th>Car Number Plate</th>
					<th>User Email</th>
					<th>Pick Up Date</th>
					<th>Drop Off Date</th>
					<th>Pick Up Location</th>
					<th>Drop Off Location</th>
					<th>Total Cost (VND)</th>
					<th>Status</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
				{data.map(item => <tr>
					<th scope="row">{item.id}</th>
					<td>{item.numberPlate}</td>
					<td>{item.userEmail}</td>
					<td>{item.pickUpDate}</td>
					<td>{item.dropOffDate}</td>
					<td>{item.pickUpLocation}</td>
					<td>{item.dropOffLocation}</td>
					<td>{item.totalCost}</td>
					<td>{item.status}</td>
					<td>
						<Button color="info" size="sm" onClick={() => onAction("edit", item.id)}>Edit</Button>&nbsp;
						<Button color="danger" size="sm" onClick={() => onAction("delete", item.id)}>Cancel</Button>&nbsp;
						<Button color="success" size="sm" onClick={() => onAction("view", item.id)}>Checkout</Button>
					</td>
				</tr>)}
			</tbody>
		</Table>
	);
};

export default BookingTable;