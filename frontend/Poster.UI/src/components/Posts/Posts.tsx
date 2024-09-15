import { FC } from "react";
import { IPost } from "../../API/posts.api";
import Post from "./Post";
import styles from "./posts.module.css";
import { useSelector } from "react-redux";

interface IPostsProps {
  read: (post: IPost) => Promise<void>;
}

/**
 * Компонент постов.
 * @param props Пропсы.
 * @returns FC
 */
const Posts: FC<IPostsProps> = (props) => {
  const { read } = props;
  const posts = useSelector((state: { posts: IPost[] }) => state.posts);

  return (
    <div className={styles.posts}>
      {posts.map((post) => (
        <Post key={post.id} read={read} post={post} />
      ))}
    </div>
  );
};

export default Posts;
