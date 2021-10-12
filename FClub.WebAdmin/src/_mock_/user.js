import faker from "faker";
import { sample } from "lodash";
// utils
import { mockImgAvatar } from "../Utils/mockImages";

// ----------------------------------------------------------------------

const users = [...Array(24)].map((_, index) => ({
  id: faker.datatype.uuid(),
  avatarUrl: mockImgAvatar(index + 1),
  name: faker.name.findName(),
  company: faker.company.companyName(),
  isVerified: faker.datatype.boolean(),
  status: sample(["active", "banned"]),
  role: sample(["Manager", "Member"]),
}));

export default users;