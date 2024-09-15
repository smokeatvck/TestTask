import { FC } from "react";
import styles from "./button.module.css";

type Color = "red" | "green";

interface IButtonProps {
  title: string;
  color: Color;
  icon?: string;
  onClick: () => void | Promise<void>;
}

const Button: FC<IButtonProps> = (props) => {
  const { title, icon, color, onClick } = props;
  return (
    <button
      onClick={onClick}
      style={{ background: color }}
      className={styles.button}
    >
      {icon && <img className={styles.img} src={icon} />}
      {title}
    </button>
  );
};

export default Button;
