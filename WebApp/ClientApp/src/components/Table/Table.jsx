import React from "react";
import styled from "styled-components";

const TableHeader = styled.tr`
	background-color: gray;
	color: black;
`;

const Table = ({ headers, data }) => {
	return (
		<table>
			<tbody>
				<TableHeader>
					{headers.map(header => <th>{header.display}</th>)}
				</TableHeader>
				{data.map(item => <tr>
					{headers.map(header => <td>{item[header.name]}</td>)}
				</tr>)}
			</tbody>
		</table>
	);
};

export default Table;