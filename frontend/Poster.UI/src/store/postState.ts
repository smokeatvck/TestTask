import { IPost } from "../API/posts.api";

export interface PostState {
  posts: IPost[];
}

const initialState: PostState = {
  posts: [],
};

export default initialState;
