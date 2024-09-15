import { EDIT_POST, GET_POSTS, PostActionTypes } from "./postActions";
import initialState, { PostState } from "./postState";

const reducer = (state = initialState, action: PostActionTypes): PostState => {
  switch (action.type) {
    case EDIT_POST:
      const updatedPosts = state.posts.map((post) =>
        post.id === action.payload.id ? action.payload : post
      );
      return {
        ...state,
        posts: updatedPosts,
      };
    case GET_POSTS:
      return {
        ...state,
        posts: [...state.posts, ...action.payload],
      };
    default:
      return state;
  }
};

export default reducer;
