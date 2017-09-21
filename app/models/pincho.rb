class Pincho < ApplicationRecord
    has_many :votes
    has_many :voters, through: :votes, source: :user
end
