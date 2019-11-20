class TableColumn {
	constructor(name, display = null) {
		this.name = name;
		this.display = display || this.name;
	}
}

export default TableColumn;