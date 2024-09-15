import { FC, useEffect, useState } from "react";
import InfiniteScroll from "react-infinite-scroll-component";
import { editPost, fetchPosts, IPost } from "../API/posts.api";
import Posts from "../components/Posts";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { getPosts, updatePost } from "../store/postActions";
import { Action } from "redux";

/**
 * Страница с постами
 * @returns FC
 */
const PostPage: FC = () => {
  const limit = 10;
  const [lastId, setLastId] = useState<number>(0);
  const posts = useSelector((state: { posts: IPost[] }) => state.posts);
  const dispatch = useDispatch();

  const fetchData = async () => {
    const data = await fetchPosts(limit, lastId);
    if (data && data.length > 0) {
      dispatch<Action>(getPosts(data));
      setLastId(data[data.length - 1].id);
    }
  };

  const readPost = async (model: IPost) => {
    const post = { ...model };
    post.isRead = !post.isRead;
    const response = await editPost(post);
    if (response) {
      dispatch<Action>(updatePost(post));
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <InfiniteScroll
      dataLength={posts.length}
      next={fetchData}
      hasMore={true}
      loader={<h3>Загрузка...</h3>}
    >
      <Posts read={readPost} />
    </InfiniteScroll>
  );
};

export default PostPage;
