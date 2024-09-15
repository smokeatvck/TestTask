import { FC } from "react";
import { IPost } from "../../API/posts.api";
import styles from "./posts.module.css";
import checkSvg from "../../assets/check.svg";
import closeSvg from "../../assets/close.svg";
import Button from "../Button";

interface IPostProps {
  post: IPost;
  read: (post: IPost) => Promise<void>;
}

/**
 * Компонент поста.
 * @param props Пропсы.
 * @returns FC
 */
const Post: FC<IPostProps> = (props) => {
  const { post, read } = props;

  return (
    <div className={styles.post}>
      <div className={styles.title}>{post.title}</div>
      <div className={styles.body}>{post.body}</div>
      <div className={styles.button}>
        {post.isRead ? (
          <Button
            onClick={() => read(post)}
            color="green"
            icon={checkSvg}
            title="Прочитано"
          />
        ) : (
          <Button
            onClick={() => read(post)}
            color="red"
            icon={closeSvg}
            title="Не прочитано"
          />
        )}
      </div>
    </div>
  );
};

export default Post;
