class TableColumn {
	constructor(name, display = null, isHidden = false) {
		this.name = name;
		this.display = display || this.name;
		this.isHidden = isHidden;
	}
}

export default TableColumn;