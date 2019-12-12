import React from "react";
import { Table, Button } from "reactstrap";

const UserTable = ({ data, onAction }) => {
	return (
		<Table striped>
			<thead>
				<tr>
					<th>ID</th>
					<th>Email</th>
					<th></th>
				</tr>
			</thead>
			<tbody>
				{data.map(item => <tr>
					<th scope="row">{item.id}</th>
					<td>{item.email}</td>
					<td>
						<Button color="danger" size="sm" onClick={() => onAction("delete", item.id)}>Delete</Button>
					</td>
				</tr>)}
			</tbody>
		</Table>
	);
};

export default UserTable;