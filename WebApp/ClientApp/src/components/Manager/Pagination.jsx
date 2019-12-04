import React from "react";
import { Pagination as PaginationStrap, PaginationItem, PaginationLink } from "reactstrap";

const Pagination = ({ totalPages, currentPage, onClick }) => {
	const setupPagination = () => {
		let arr = [];
		for (let i = 1; i <= totalPages; i++) {
			arr.push(
				<PaginationItem active={currentPage === i}>
					<PaginationLink onClick={() => onClick(i)}>{i}</PaginationLink>
				</PaginationItem>
			);
		}

		return arr;
	};
	
	return (
		<PaginationStrap className="center-pagination">
			{setupPagination()}
		</PaginationStrap>
	);
};

export default Pagination;