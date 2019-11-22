import React from "react";
import styled from "styled-components";

const ModalWrapper = styled.div`
	position: fixed;
	z-index: 1;
	left: 0;
	top: 0;
	width: 100%;
	height: 100%;
	overflow: auto;
	background-color: rgba(0, 0, 0, 0.5);
`;

const ModalBody = styled.div`
	margin: 5% auto;
	width: 80%;
	background-color: white;
`;

const ModalHeader = styled.div`
	display: grid;
	height: 3.5em;
	grid-template-columns: auto 3.5em;
	padding-left: 0.75em;
	line-height: 1.15em;
`;

const ModalContent = styled.div`
	box-sizing: border-box;
	padding: 1.25em;
`;

const Modal = ({ title = "", onClose, children }) => {
	return (
		<ModalWrapper>
			<ModalBody>
				<ModalHeader>
					<h3>{title}</h3>
					<button onClick={onClose}>&times;</button>
				</ModalHeader>
				<ModalContent>
					{children}
				</ModalContent>
			</ModalBody>
		</ModalWrapper>
	);
};

export default Modal;