﻿namespace Application
{
    public enum UseCasesEnum
    {
        UserRegistration = 1, //create user
        WorkspaceDeletion = 2, //delete workspace
        WorkspaceRetrieval = 3, //get workspace
        WorkspaceCreation = 4, //create workspace
        WorkspaceModification = 5, //update document contents, or any workspace's owner or parent
        UserWorkspaceUseCaseModification = 6, //update user usecase for a workspace
        WorkspaceRetrievalByLink = 7, //get workspace name and contents by link
    }
}
