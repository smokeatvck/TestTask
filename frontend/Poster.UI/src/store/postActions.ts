import { IPost } from "../API/posts.api";

export const ADD_POSTS = "ADD_POSTS";
export const EDIT_POST = "EDIT_POST";
export const GET_POSTS = "GET_POSTS";

interface UpdatePostAction {
  type: typeof EDIT_POST;
  payload: IPost;
}

interface GetPostsAction {
  type: typeof GET_POSTS;
  payload: IPost[];
}

export type PostActionTypes = UpdatePostAction | GetPostsAction;

export const updatePost = (post: IPost): UpdatePostAction => ({
  type: EDIT_POST,
  payload: post,
});

export const getPosts = (posts: IPost[]): GetPostsAction => ({
  type: GET_POSTS,
  payload: posts,
});
