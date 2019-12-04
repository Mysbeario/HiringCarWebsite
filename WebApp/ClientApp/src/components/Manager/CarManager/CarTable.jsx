import React from "react";
import { Table, Button } from "reactstrap";

const CarTable = ({ data, onAction }) => {
	return (
		<Table striped>
			<thead>
				<tr>
					<th>ID</th>
					<th>Number Plate</th>
					<th>Color</th>
					<th>Type</th>
					<th>Status</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
				{data.map(item => <tr>
					<th scope="row">{item.id}</th>
					<td>{item.numberPlate}</td>
					<td>{item.color}</td>
					<td>{item.carTypeName}</td>
					<td></td>
					<td>
						<Button color="info" size="sm" onClick={() => onAction("edit", item.id)}>Edit</Button>&nbsp;
						<Button color="danger" size="sm" onClick={() => onAction("delete", item.id)}>Delete</Button>
					</td>
				</tr>)}
			</tbody>
		</Table>
	);
};

export default CarTable;