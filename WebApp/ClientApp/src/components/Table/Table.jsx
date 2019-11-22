import React from "react";
import { Table as TableStrap, Button } from "reactstrap";

const Table = ({ headers, data, hasActionColumn = false, onEditSelected, onDeleteSelected }) => {
	return (
		<TableStrap striped>
			<thead>
				<tr>
					{headers.map(header => <th>{header.display}</th>)}
					{hasActionColumn && <th>Action</th>}
				</tr>
			</thead>
			<tbody>
				{data.map(item => <tr>
					{headers.map(header => header.name === "id" ?
						<th scope="row">{item.id}</th> :
						<td>{item[header.name]}</td>)}
					{hasActionColumn && <td>
						<Button color="info" size="sm" onClick={() => onEditSelected(item.id)}>Edit</Button>&nbsp;
						<Button color="danger" size="sm" onClick={() => onDeleteSelected(item.id)}>Delete</Button>
					</td>}
				</tr>)}
			</tbody>
		</TableStrap>
	);
};

export default Table;