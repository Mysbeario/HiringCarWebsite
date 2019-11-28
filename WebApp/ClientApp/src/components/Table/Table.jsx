import React from "react";
import { Table as TableStrap, Button } from "reactstrap";
import { toString } from "../../utilities";

const Table = ({ headers, data, hasActionColumn = false, onActionSelected }) => {
	return (
		<TableStrap striped>
			<thead>
				<tr>
					{headers.map(header => !header.isHidden && <th>{header.display}</th>)}
					{hasActionColumn && <th>Action</th>}
				</tr>
			</thead>
			<tbody>
				{data.map(item => <tr>
					{headers.map(header => header.name === "id" ?
						<th scope="row">{item.id}</th> :
						!header.isHidden && <td>{toString(item[header.name])}</td>)}
					{hasActionColumn && <td>
						<Button color="info" size="sm" onClick={() => onActionSelected(item.id, "edit")}>Edit</Button>&nbsp;
						<Button color="danger" size="sm" onClick={() => onActionSelected(item.id, "delete")}>Delete</Button>
					</td>}
				</tr>)}
			</tbody>
		</TableStrap>
	);
};

export default Table;