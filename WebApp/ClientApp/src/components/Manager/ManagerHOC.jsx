import React, { useState, useEffect, createContext } from "react";
import axios from "axios";

export const ManagerContext = createContext();

const withManager = (WrappedComponent, url, pageSize = 10) => {
	return () => {
		const [entityData, setEntityData] = useState([]);
		const [totalPages, setTotalPages] = useState(1);
		const [searchString, setSearchString] = useState("");
		const [currentPage, setCurrentPage] = useState(1);
		const [sortBy, setSorting] = useState("id");
		const [currentEditedItem, setCurrentEditedItem] = useState(null);
		const [isAddFormOpen, openAddForm] = useState(false);
		const [isEditFormOpen, openEditForm] = useState(false);
		const [isDeleteFormOpen, openDeleteForm] = useState(false);

		const updateData = async () => {
			const { data } = await axios.get(`${url}${currentPage}?size=${pageSize}&sortBy=${sortBy}${(searchString.trim() ? "&search=" + searchString : "")}`);
			setEntityData(data);
		};

		const modifyData = (action, item) => {
			setCurrentEditedItem(item);
			if (action === "edit") {
				openEditForm(true);
			}
			else if (action === "delete") {
				openDeleteForm(true);
			}
		};

		const findItem = id => {
			if (!id) return;

			return entityData.find(i => i.id === id);
		};

		useEffect(() => {
			(async () => {
				const { data } = await axios.get(`${url}?size=${pageSize}${(searchString.trim() ? "&search=" + searchString : "")}`);
				setTotalPages(data);
			})();

			if (currentPage === 1) {
				updateData();
			}
			else {
				setCurrentPage(1);
			}
		}, [searchString]);

		useEffect(() => {
			updateData();
		}, [currentPage, sortBy]);

		return (
			<ManagerContext.Provider
				value={{
					setSearchString,
					setSorting,
					entityData,
					modifyData,
					isAddFormOpen,
					openAddForm,
					updateData,
					totalPages,
					currentPage,
					setCurrentPage,
					isEditFormOpen,
					openEditForm,
					findItem,
					isDeleteFormOpen,
					openDeleteForm,
					currentEditedItem
				}}
			>
				<WrappedComponent />
			</ManagerContext.Provider>
		);
	}
};

export default withManager;