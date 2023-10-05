from django.db import models
from django.contrib.auth.models import User
from . import Pintxo
from .values import TastesValues, PresentationsValues, OriginalitiesValues

from .choices import Tastes, Presentations, Originalities

class Vote(models.Model):
    taste_vote = models.CharField(max_length=2, choices=Tastes.choices)
    presentation_vote = models.CharField(max_length=2, choices=Presentations.choices)
    originality_vote = models.CharField(max_length=2, choices=Originalities.choices)
    pintxo = models.ForeignKey(Pintxo, on_delete=models.CASCADE)
    voter = models.ForeignKey(User, on_delete=models.CASCADE)

    def __unicode__(self):
        return f"{self.voter.get_full_name()} voted {self.pintxo.name}({self.pintxo.owner.get_full_name()}) with  {self.taste_vote} - {self.presentation_vote} - {self.originality_vote}"
    
    def __str__(self):
        return f"{self.voter.get_full_name()} voted {self.pintxo.name}({self.pintxo.owner.get_full_name()}) with  {self.taste_vote} - {self.presentation_vote} - {self.originality_vote}"

    @classmethod
    def get_contest_result(cls, contest):
        votes = Vote.objects.filter(pintxo__contest=contest)
        total = 0
        total_votes = {}

        for vote in votes:
            taste = TastesValues[vote.taste_vote]
            presentation = PresentationsValues[vote.presentation_vote]
            originality = OriginalitiesValues[vote.originality_vote]
            if vote.pintxo.pk not in total_votes:
                total_votes[vote.pintxo.pk] = {}

            total_votes[vote.pintxo.pk].setdefault('taste', 0)
            total_votes[vote.pintxo.pk].setdefault('presentation', 0)
            total_votes[vote.pintxo.pk].setdefault('originality', 0)    

            total_votes[vote.pintxo.pk]["taste"] += taste
            total_votes[vote.pintxo.pk]["presentation"] += presentation
            total_votes[vote.pintxo.pk]["originality"] += originality

        for key, vote in total_votes.items():
            vote['result'] = (vote['taste']*0.7) + (vote['presentation']*0.15) + (vote['originality']*0.15)

        return sorted(total_votes.items(), key=lambda x: (x[1]['result'], x[1]), reverse=True)
