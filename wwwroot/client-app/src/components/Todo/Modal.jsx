/* eslint-disable react/prop-types */
import "../../styles/css/Modal.css";

const Modal = ({ isOpen, onClose, children }) => {
  if (!isOpen) return null;

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <button className="modal-close" onClick={onClose}></button>
        {children}
      </div>
    </div>
  );
};

export default Modal;
