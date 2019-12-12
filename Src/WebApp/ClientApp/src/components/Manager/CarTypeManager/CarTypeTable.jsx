import React from "react";
import { Table, Button } from "reactstrap";

const CarTypeTable = ({ data, onAction }) => {
	return (
		<Table striped>
			<thead>
				<tr>
					<th>ID</th>
					<th>Type</th>
					<th>Seat</th>
					<th>Cost (VND per day)</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
				{data.map(item => <tr>
					<th scope="row">{item.id}</th>
					<td>{item.name}</td>
					<td>{item.seat}</td>
					<td>{item.cost}</td>
					<td>
						<Button color="info" size="sm" onClick={() => onAction("edit", item.id)}>Edit</Button>&nbsp;
						<Button color="danger" size="sm" onClick={() => onAction("delete", item.id)}>Delete</Button>
					</td>
				</tr>)}
			</tbody>
		</Table>
	);
};

export default CarTypeTable;